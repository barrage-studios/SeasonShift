#! /bin/sh

PROJECT_PATH=$(pwd)/$UNITY_PROJECT_PATH
UNITY_BUILD_DIR=$(pwd)/Build
LOG_FILE=$UNITY_BUILD_DIR/unity-mac.log


ERROR_CODE=0
echo "Items in project path ($PROJECT_PATH):"
ls "$PROJECT_PATH"


echo "Building project for Mac..."
mkdir $UNITY_BUILD_DIR
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile \
  -projectPath "$PROJECT_PATH" \
  -buildOSX64Player  "$(pwd)/build/osx/ci-build.app" \
  -username "$USERNAME" \
  -password "$PASSWORD" \
  -quit \
  | tee "$LOG_FILE"
  
if [ $? = 0 ] ; then
  echo "Building Mac pkg completed successfully."
  ERROR_CODE=0
else
  echo "Building Mac pkg failed. Exited with $?."
  ERROR_CODE=1
fi

#echo 'Build logs:'
#cat $LOG_FILE

echo "Finishing with code $ERROR_CODE"
exit $ERROR_CODE