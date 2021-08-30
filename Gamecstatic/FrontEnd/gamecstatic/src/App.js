import './App.scss';
import Home from './Home/Home';
import React from 'react';
import {BrowserRouter,Route, Switch} from 'react-router-dom';
import {useSelector,useDispatch} from "react-redux";
import {bindActionCreators} from "redux";
import {actionCreator} from "./state/index";
import Game from './Game';
import {UploadGame} from './UploadGame/UploadGame';
require('dotenv').config();


function App() {
  const state = useSelector((state) => state);
  const dispatch = useDispatch();
  const AC = bindActionCreators(actionCreator,dispatch);
  return (
    <BrowserRouter>
      <Switch>
          <Route path="/" component={Home} exact/>
          <Route path="/item/:id" component={Home} exact/>
          <Route path="/games" component={Game} exact/>
          <Route path="/uploadgame" component={UploadGame} exact/>
      </Switch>
    </BrowserRouter>
  );
}

export default App;