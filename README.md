# IdentityApplication

This .NET MVC 5 project simulates an online store.

I have used .NET Identity to handle new user registrations, logins, and account confirmation emails. I have used Mailgun as my email sending service.

------------------------------------------------------

Steps to install on a development machine:

1) Clone the git repo down onto your development machine. 
C:\Users\gellm\Gell\examples_of_my_work\IdentityApplication

2) Install nvm for Windows, using the Windows MSI installer.
You will have to uninstall node and npm first.
Please follow the instructions at:
https://github.com/coreybutler/nvm-windows

3) Use nvm to install node version 8.9.4 using the following command:
nvm install 8.9.4
(This will install node 8.9.4 and npm 5.6.0)

4) install bower by typing:
npm install -g bower

5) Install the required node modules by typing
npm install
This will install lots of things under IdentityApplication\node_modules

6) Install the required bower modules by typing
bower install

7) install grunt by typing
npm install -g grunt-cli

8) run the grunt tasks by typing
grunt

9) Open the Visual Studio solution, and compile and run the application.