# AphasiaProject

## Uruchamianie client app
### kompilator scss
Ustawienie się na folder projektu aplikacji klienckiej, następnie uruchomienie konsoli w celu zainstalowania moduly node.js oraz kompilatora scss
```
npm init -y
```
```
npm install sass --save-dev
```
### instalacja bibliotek
```
npm install
```

W głównym katalogu powinnien się zatem znaleść folder node_modules oraz plik 'package.json'
```
{
  "name": "AphasiaClientApp",
  "version": "1.0.0",
  "description": "",
  "main": "index.js",
  "dependencies": {},
  "devDependencies": {
    "sass": "^1.49.8"
  },
  "scripts": {
    "sass":"sass"
  },
  "keywords": [],
  "author": "",
  "license": "ISC"
}
```
