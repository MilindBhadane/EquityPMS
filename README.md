# Equity Position Management System

This project had below pre-requisite
1. Visual Studio with framework v4.5.2
2. SQL Server (Express)
3. WCF Web Service

- SQL Database Backup and Restore: 
  - Along with this project I have attached SQLDB Backup file.
  - Please restore this SQL DB in your SQL Server with database name: EquityPositionsDB

- SQL DB connection in Code
  - Replace connection String name with your server name in EqtyPMS.DAL project App.Config file. C:\Git\EqtyPMS\EqtyPMS.DAL\App.config

- Current Connection String: connectionString="Data Source=DESKTOP-HGBCI0T\SQLEXPRESS;Initial Catalog=EquityPositionsDB;Integrated Security=True"

- How to run: I have to run webservice and WPF projects from same solution hence added Start External Program command in WebService project. Please change the path as per your machine.

Getting Started:

4 Trades are added by Default.
 ![image](https://user-images.githubusercontent.com/82780132/198308877-e74b0baf-ed5d-4412-8c90-512bdba6c70e.png)


After 1st transaction:

TransactionID	TradeID	Version	SecurityCode	Quantity	Insert/Update/Cancel	Buy/Sell

1	1	1	REL	50	INSERT	BUY
![image](https://user-images.githubusercontent.com/82780132/198308919-a86c5239-9aa1-4d06-9453-5bad60897698.png)


After 2nd Transaction:

TransactionID	TradeID	Version	SecurityCode	Quantity	Insert/Update/Cancel	Buy/Sell

2	2	1	ITC	40	INSERT	SELL
![image](https://user-images.githubusercontent.com/82780132/198308964-c435ae08-cc32-4bb7-baf6-3241ebb355d4.png)


After 3rd Transaction

TransactionID	TradeID	Version	SecurityCode	Quantity	Insert/Update/Cancel	Buy/Sell

3	3	1	INF	70	INSERT	BUY
![image](https://user-images.githubusercontent.com/82780132/198309022-797ddb74-f505-4d45-bd32-365c02a2eabb.png)

 

After 4th transaction:

TransactionID	TradeID	Version	SecurityCode	Quantity	Insert/Update/Cancel	Buy/Sell

4	1	2	REL	60	UPDATE	BUY
![image](https://user-images.githubusercontent.com/82780132/198309046-825496e5-4bfc-4c51-8111-23c0ba0832d4.png)



After 5th Transaction:

TransactionID	TradeID	Version	SecurityCode	Quantity	Insert/Update/Cancel	Buy/Sell

5	2	2	ITC	30	CANCEL	BUY
![image](https://user-images.githubusercontent.com/82780132/198309094-74f660cb-3050-4473-8285-7bad80bc4e82.png)

 

After 6th Transaction:

TransactionID	TradeID	Version	SecurityCode	Quantity	Insert/Update/Cancel	Buy/Sell

6	4	1	INF	20	INSERT	SELL
![image](https://user-images.githubusercontent.com/82780132/198309130-5b82b062-42fb-4873-b7ff-fc159b25fedd.png)

 

