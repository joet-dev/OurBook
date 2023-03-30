# OurBook - Billing Ledger :money_with_wings:

## Description
This is a simple billing program geared towards housemates/tenants to simplify sharing and tracking bills.

**How it works**

Users can be registered to the application as either admins or users. Admin users can 
upload bills to the SQL server with details such as tile, invoice no., value amount, 
date created and the users it applies to. 

Users can then view their bills through their homepage. They can check bills they
have paid off, automatically updating the servers, recording the date and time of payment and the 
date and time once the bill has been fully paid by all recipitents. 

This program wasn't necessarily built to be fully useful for its usecase, but rather as a project 
through which I could gain programming skills and techniques in c# and SQL. 
Along with these skills I learnt more about application design, cryptography, and database design.

##### Possible Future Features
Even though it is quite inefficient to use now, with added features I could see this program 
increasing the efficiency of distributing and tracking bills. 

Some features or changes could include: 
- The use of an email API to automatically notify users of new bills, 
possibly allowing them to confirm payment through a weblink in the email 
(though this may increase security and data integrity vulnerabilities).
- The ability for users & admins to review paid bills and make adjustments to them. 
- The ability for admins to request a excel sheet ledger of the bills and relevant details. 
- Converting the entire windows application to a web app to improve user accessibility. 

<br>

## TODO:

