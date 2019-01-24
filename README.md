# IdentityApplication

This .NET MVC 5 project simulates an online store.

I have used .NET Identity to handle new user registrations, logins, and account confirmation emails. I have used Mailgun as my email sending service.

------------------------------------------------------

Steps to install on a development machine:

* Clone the git repo down onto your development machine.

* Install nvm for Windows, using the Windows MSI installer.
You will have to uninstall node and npm first.
Please follow the instructions at:
https://github.com/coreybutler/nvm-windows

* Use nvm to install node, with the following command:
`nvm install 8.9.4`
(This will install node 8.9.4 and npm 5.6.0)

* install bower by typing:
`npm install -g bower`

* Install the required node modules by typing
`npm install`
This will install lots of things under: IdentityApplication\node_modules

* Install the required bower modules by typing:
`bower install`

* install grunt by typing
`npm install -g grunt-cli`

* run the grunt tasks by typing
`grunt`

* Open the Visual Studio solution, and compile and run the application.