# rent-a-bike

The global approach is write code following the S.O.L.I.D. principles to ensure maintanability and testability.

First of all, identifying the parts of the system that could change more often, in this case, the cost algorithm calculating, in which i use a strategy pattern.

Also, i coded to interfaces rather than implementations, to allow future extensions and test the code.

To run the tests, download code from "rama1" branch, open with WS2015 or higher and run test from test explorer.

Last changes:
- Changed DRMS from Sql Server to MySql. 
- Changed from EF to plain Ado.Net in Data Access Layer
- Drop unnecesary proyect from solution


Instructions:
- download code from branch Master/rama1MySql.
- run creation database script "WebRental/sql/rentaldb_Dump20180615.sql" on MySql.
- set connection string.
- F5


Regards.

Gonzalo López
