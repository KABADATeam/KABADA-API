cd "%~dp0"
cd ..\..\kabada-ai
rem python app.py --ip=localhost --port=2222
rem python ai_daemon.py start --ip=localhost --port=2222
python ai_rest_api.py --ip=localhost --port=2222
