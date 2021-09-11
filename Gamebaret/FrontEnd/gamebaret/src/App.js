import './App.scss';
import Home from './Home/Home';
import React from 'react';
import {BrowserRouter,Route, Switch} from 'react-router-dom';
import Game from './Game/Game';
import {UploadGame} from './UploadGame/UploadGame';
import ProtectedRoute from './Login/ProtectedRoute';
import Navigation from './CommonElements/Navigation/Navigation';
import Footer from './CommonElements/Footer/Footer';
require('dotenv').config();

function App() {
  return (
    <BrowserRouter>
      <Navigation />
      <Switch>
        <Route path="/" component={Home} exact/>
        <Route path="/game/:id" component={Game} exact/>
        <ProtectedRoute path="/uploadgame" component={UploadGame} exact/>
      </Switch>
      <Footer />
    </BrowserRouter>
  );
}

export default App;