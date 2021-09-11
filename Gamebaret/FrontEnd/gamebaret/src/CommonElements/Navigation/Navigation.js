import './Navigation.scss';
import {useEffect, useState} from 'react';
import { useDispatch } from 'react-redux';
import { fetchGames } from "../../state/action-creator/games";
import { Link } from 'react-router-dom'
import AuthSection from './AuthSection';
import {GameSearch} from '../../Home/Components/Games/GamesSortingBar/GameSearch';
import GameItem from '../../Home/Components/Games/GameItem';
import OperationsSection from './OperationsSection';
import logo from '../../assets/image/temporarylogo.PNG'

function Navigation() {
    const onSearch = (SearchTerm) => {
        setState({...state,SearchTerm})
    }
    const onNavigateGame = () => {
      setGames(null);
      setState({
        SearchTerm : "",
        SortBy : "rating",
        Tags:[],
        Categories:[],
        Page: 1
      });
    }
    const dispatch = useDispatch()
    const [games, setGames] = useState(null)
    const [state,setState] = useState({
      SearchTerm : "",
      SortBy : "rating",
      Tags:[],
      Categories:[],
      Page: 1
    });
    useEffect(() => {
      if(state.SearchTerm !== "")
        dispatch(fetchGames(state)).then(res => setGames(res)).catch(err => console.log(err))
      else setGames(null)
    }, [state])
    let searchResult = ""
    if(games !== null){
      searchResult = games.results.map((game) =>
        <div key={game.id} id="search-bar-result-wrapper"><GameItem game={game}/></div>
       );
    }
    return (
      <div id="navigation-container" className="w-100 d-flex justify-content-between">
        <div className=" d-flex align-items-center">
          <Link id="main-name" to="/"><img src={logo}></img><h6>Gameberet</h6></Link>
        </div>
        <div className="d-flex flex-column h-100 w-30 justify-content-center">
          <div id="game-search-bar">
            <GameSearch className="w-100" onSearch={onSearch} />
            <div id="game-search-result" onClick={onNavigateGame} className="w-100">{searchResult}</div>
          </div>
        </div>
        <div className="w-15 d-flex justify-content-between mr-40">
          <OperationsSection />
          <AuthSection />
        </div>
      </div>
    );
}
export default Navigation; 