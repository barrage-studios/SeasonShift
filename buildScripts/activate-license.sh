echo "Setting up License..."
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile \
  -serial "$KEY" \
  -username "$USERNAME" \
  -password "$PASSWORD" \
  -quit \
  | tee "$LOG_FILE"
