Feature: 004SettingFunctionality

A short summary of the feature


Scenario: Access to setting icon of WebClient.
	Given I am at the Web Client login page.
	When I click on the setting icon.
	Then A new Iframe with heading "Settings" is appeared.

Scenario: Multiple language selection check.
	Given I am at the Web Client login page.
	When I click on the setting icon.
	When I select <Language> from drop down.
	Then I get <UsernameText> in <Language> language.
	Examples: 
		| Language   | UsernameText        |
		| Arabic     | اسم المستخدم        |
		| Dansk      | Bruger navn         |
		| Deutsch    | Benutzername        |
		| English    | User name           |
		| Español    | Nombre de usuario   |
		| Français   | Nom d'utilisateur   |
		| Italiano   | Nome utente         |
		| Nederlands | Gebruikersnaam      |
		| Polski     | Użytkownik          |
		| Português  | Utilizador          |
		| Român      | Nume utilizator     |
		| Russian    | User name           |
		| Slovenčina | User name           |
		| Svenska    | Användarnamn        |
		| Thai       | รหัสผู้ใช้               |
		| Türkçe     | Kullanıcı adı       |
