# storj-tardigrade-windows-gui
A GUI client for Windows tardigrade Uplink CLI.

## How to use it
Simply download latest release from [GitHub Page](https://github.com/Carlotronics/storj-tardigrade-windows-gui/releases "Releases"), and run it.
You will need to download Uplink CLI, by following first instruction on [Tardigrade official documentation](https://documentation.tardigrade.io/api-reference/uplink-cli "Documentation").

## First run
Open the file `StorjTardigradeWindowsGui.exe`. If you haven't yet setup Uplink CLI, you will be asked for a satellite, your API key and an encryption passphrase - the one that will be used to encrypt your data on Storj network.

## Features
This client allows you to manage your buckets, upload, download, delete and display files inside bucket.

### Create a bucket
Click on `Create bucket` button, and enter a bucket name.
Be careful that bucket's name must begin with with a lowercase letter or number.

### List files inside bucket
Select a bucket in the list on the left, and click `List files` inside `Bucket: *name*` section.

### Upload file into bucket
Inside `Bucket: *name*` section, click on `Upload file` button.
Select the file you'd like to upload, confirm, and enter the name under which you want to save the file on the Storj network.

### Download file
Inside `My bucket's files` section, select the file you'd like to download, and click `Download file` button.
You will be asked where to save the file. The Uplink CLI window will then allow you to follow the download of the file.

### Open file
Inside `My bucket's files` section, double-click on the file you'd like to download, or select it and press `Enter`.
The file is then downloaded and opened with default program.

## Uplink CLI compatibility
Tested and working with :

| Name           | Version   |
|:--------------:|:---------:|
| Uplink CLI x64 | v0.30.5   |