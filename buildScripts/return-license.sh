echo "Returning License..."
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile \
  -username "$USERNAME" \
  -password "$PASSWORD" \
  -returnlicense \
  -quit \
  | tee "$LOG_FILE"
