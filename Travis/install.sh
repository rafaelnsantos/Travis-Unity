#! /bin/sh

set -e

BASE_URL=https://download.unity3d.com/download_unity
HASH=a9f86dcd79df
VERSION=2017.3.0f3

download() {
 file=$1
 url="$BASE_URL/$HASH/$package"

 echo "Downloading from $url: "
 cd Unity
 curl -o `basename "$package"` "$url"
 cd ../
}

install() {
 package=$1
 filename=`basename "$package"`
 packagePath="Unity/$filename"
 if [ ! -f $packagePath ] ; then
   echo "$packagePath not found. downloading `basename "$packagePath"`"
   download "$package"
 fi

 echo "Installing "`basename "$package"`
 sudo installer -dumplog -package $packagePath -target /
}

if [ ! -d "Unity" ] ; then
 mkdir -p -m 777 Unity
fi

install "MacEditorInstaller/Unity-$VERSION.pkg"
install "MacEditorTargetInstaller/UnitySetup-Windows-Support-for-Editor-$VERSION.pkg"
install "MacEditorTargetInstaller/UnitySetup-Linux-Support-for-Editor-$VERSION.pkg"
install "MacEditorTargetInstaller/UnitySetup-WebGL-Support-for-Editor-$VERSION.pkg"
# install "MacEditorTargetInstaller/UnitySetup-iOS-Support-for-Editor-$VERSION.pkg"