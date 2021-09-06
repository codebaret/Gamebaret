import './Navigation.scss';
import { useState } from 'react'
import { useSelector } from 'react-redux'
import { Link } from 'react-router-dom'
import AuthSection from './AuthSection';
import {GameSearch} from '../../Home/Components/Games/GamesSortingBar/GameSearch'
import OperationsSection from './OperationsSection';

function Navigation() {
    const onSearch = (SearchTerm) => {
      //setState({...state,SearchTerm,Page:1})
      console.log(SearchTerm);
    }
    return (
      <div id="navigation-container" className="w-100 d-flex justify-content-between">
        <div className=" d-flex align-items-center">
          <Link id="main-name" to="/"><img src="temporarylogo.png"></img><h6>Gameberet</h6></Link>
        </div>
        <GameSearch onSearch={onSearch} />
        <div className="w-10 d-flex justify-content-between">
          <OperationsSection />
          <AuthSection />
        </div>
      </div>
    );
}
export default Navigation; 