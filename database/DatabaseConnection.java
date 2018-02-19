package database;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

public class DatabaseConnection {

	public void doConnection() {
		try {
			Class.forName("org.postgresql.Driver");
			Connection con = DriverManager.getConnection("jdbc:postgresql://localhost:5432/Amazone_db", "postgres","admin"); //path in the postgresql manager
			PreparedStatement stmt = con.prepareStatement("select * from mail.role");
			ResultSet Rs =stmt.executeQuery();
			while(Rs.next()){ System.out.println(Rs.getInt(1) + " "+ Rs.getString(2));
				
			}
		}
		catch(Exception e){
			System.out.println(e.getMessage());
		}
	}
	
	
}
