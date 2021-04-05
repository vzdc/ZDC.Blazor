cd /home/jake/ZDC.Blazor

export TMPDIR=/tmp/NuGetScratch/

mkdir -p ${TMPDIR}

sudo systemctl stop blazor

sudo dotnet publish --output /var/www/ZDC.Blazor --configuration Release

cd /home/jake/ZDC.Blazor/ZDC.Blazor

sudo cp appsettings.json /var/www/ZDC.Blazor/appsettings.json

cd /var/www/ZDC.Blazor

sudo chmod -R 755 *

sudo systemctl start blazor
