## Severalpens Gift Registry
_A hybrid between 'Secret Santa' and a wedding gift registry_
### 2018 Edition
---
\
\
\
Using the Gift Organizer, members can:

- Share gift ideas
- Organise and jointly contibute to gifts
- Create a wishlist for themselves or others
- All without revealing anything to the recipient!

The Gift Organizer is designed as follows:

- A logged in user can create a Gift Organizer and specify its members and their email address.
- When members of the create Gift Organizer sign up with their email address they'll be able to access registries they're a member of. Or create their own.
- Members can suggest gift ideas for themselves or others on the list.
- The Gift list will only display gift ideas where the member has suggested it or the member is not a recipient.

---

## Tech details
This was built using a Visual Studio .Net Framework MVC template circa 2018. The database used is Sql Server.

- Clone repo
- Open in Visual Studio >= 2018
- Find and update any `<connectionStrings>`
	- Run Sql Server and connect to localhost using the 'Sever Explorer' window in VS. 
	- Right click on the connection and select 'properties' to get the correct connectionString.
- Set GR2018.UI as the startup project
- Run the application. Scaffolding will be triggered on the initial 'Register' which will build and populate the database.

