# EqtyPMS

This project had below pre-requisite
1. Visual Studio with framework v4.5.2
2. SQL Server (Express)
3. WCF Web Service


Along with this project I have attached DB Backup script.
Please restore this DB in your SQL Server with name: EquityPositionsDB

Also, Replace connection String name with your server name in EqtyPMS.DAL project App.Config file.
C:\Git\EqtyPMS\EqtyPMS.DAL\App.config

current Connection String: connectionString="Data Source=DESKTOP-HGBCI0T\SQLEXPRESS;Initial Catalog=EquityPositionsDB;Integrated Security=True"

How to run:

I have to run webservice and WPF projects from same solution hence added Start External Program command in WebService project. Please change the path as per your machine.
