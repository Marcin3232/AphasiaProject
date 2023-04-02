# AphasiaProject
## Prezentacja


https://user-images.githubusercontent.com/58747227/229345921-a9f75954-f042-4413-b2d4-ee1207946402.mp4


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
###
Istnieje możliwość zawieszenia się skryptów strony internetowej. Zaleca się wtedy wciśnięcie kompinacji klawiszy
```
Shift + F5
```
