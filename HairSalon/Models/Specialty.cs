using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
  public class Specialty
  {
    private string _specialty;
    private int _id;

    public Specialty(string specialty, int id = 0)
    {
      _specialty = specialty ;
      _id = id;
    }

    public string GetSpecialty()
    {
      return _specialty;
    }

    public int GetId()
    {
      return _id;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties (specialty) VALUES (@specialty)";
      MySqlParameter specialty = new MySqlParameter();
      specialty.ParameterName = "@specialty";
      specialty.Value = this._specialty;
      cmd.Parameters.Add(specialty);
      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static List<Specialty> GetAll()
    {
      List<Specialty> allSpecialties = new List<Specialty>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int specialtyId = rdr.GetInt32(0);
        string specialtyName = rdr.GetString(1);
        Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
        allSpecialties.Add(newSpecialty);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allSpecialties;
    }

    public static Specialty Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = id;
      cmd.Parameters.Add(searchId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int specialtyId = 0;
      string specialty = "";
      while(rdr.Read())
      {
        specialtyId = rdr.GetInt32(0);
        specialty = rdr.GetString(1);
      }
      Specialty newSpecialty = new Specialty(specialty, specialtyId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newSpecialty;
    }

    public void AddStylist(Stylist newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO specialties_stylists (specialty_id, stylist_id) VALUES (@specialtyId, @stylistId);";
      MySqlParameter specialty_id = new MySqlParameter();
      specialty_id.ParameterName = "@specialtyId";
      specialty_id.Value = _id;
      cmd.Parameters.Add(specialty_id);
      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@stylistId";
      stylist_id.Value = newStylist.GetId();
      cmd.Parameters.Add(stylist_id);
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }


    public List<Stylist> GetStylists()
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT stylists.* FROM specialties
            JOIN specialties_stylists ON (specialties.id = specialties_stylists.specialty_id)
            JOIN stylists ON (specialties_stylists.stylist_id = stylists.id)
            WHERE specialties.id = @specialtyId;";
        MySqlParameter specialtyIdParameter = new MySqlParameter();
        specialtyIdParameter.ParameterName = "@specialtyId";
        specialtyIdParameter.Value = _id;
        cmd.Parameters.Add(specialtyIdParameter);
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        List<Stylist> stylists = new List<Stylist>{};
        while(rdr.Read())
        {
          int stylistId = rdr.GetInt32(0);
          string stylistName = rdr.GetString(1);
          Stylist newStylist = new Stylist(stylistName, stylistId);
          stylists.Add(newStylist);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return stylists;
    }

// ==============================TEST METHODS================================

    public override bool Equals(System.Object otherSpecialty)
    {
      if (!(otherSpecialty is Specialty))
      {
        return false;
      }
      else
      {
        Specialty newSpecialty = (Specialty) otherSpecialty;
        bool idEquality = this.GetId().Equals(newSpecialty.GetId());
        bool specialtyEquality = this.GetSpecialty().Equals(newSpecialty.GetSpecialty());
        return (idEquality && specialtyEquality);
      }
    }

    public override int GetHashCode()
    {
        return this.GetId().GetHashCode();
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM specialties;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }
  }
}
