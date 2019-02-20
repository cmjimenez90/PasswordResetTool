# Password Reset Tool v2

## Purpose

A port of Jeff Frye's password reset tool that was orginally made usinhg Powershell. This tool was ported to Dot Net Standard using C#. Due to the nature of the port, the tool can now be installed using the supplied installer and minimum dependencies are needed. Anyone using windows 10 version 1607 or newer will be able to use the product without issue. Otherwise NET 4.5 will need to be installed prior to installing the product.

The reset tool was created to enforce the business requirment of validating a user's identity by their banner ID number (Ellucian Banner UID) before reseting their password. This is accomplished by only giving the option of reseting an AD account after entering the banner ID number provided by the user evaluating the results against the expected account informaiton that is returned.

### Working with the code base

Running the tool in debug mode will use a IActiveDirectoryRepostiory with fake data. This was done, as it was easier to mock out the repositoryservice then to create a test implementation using user account principals.

10 user accounts will be generetated internally with "VALID" Banner ID Records. These will be stored in memory during the application life cycle.

Accounts Created:
A00000001 -> A00000009

### SPECIAL BANNER ID Numbers for testing.

If you would like to simulate the password change failing use the following: "A00000001"

If you would like to simulate the reset attribute failing to change use the following:"A00000002"

### Building the Installer

**If building to use in live environment please do the following first:** 

*Before compiling the installer modify the App.Config to have the domain server that will be used to query accounts against.*

*setting name="DC_FQDN"*

#### Using Visual Studio

1. Build solution to make sure dependencies are available.

2. Build Cmjimenez.PasswordResetTool.Installer
MSI installer will be output to <<PROJECTPATH>>\PasswordResetTool\Cmjimenez.PasswordResetTool.Installer\bin\Debug

