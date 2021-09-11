import GamesFilter from "./GamesFilter/GamesFilter";
import GamesSortingBar from "./GamesSortingBar/GamesSortingBar";
import GameItem from "./GameItem";
import { fetchGames } from "../../../state/action-creator/games";
import { useDispatch } from 'react-redux';
import {useEffect, useState} from 'react';
import './Games.scss';
import Pagination from "./Pagination/Pagination";


function Games(props) {
    const dispatch = useDispatch()
    const [games, setGames] = useState({results:[],pageCount:0,pageSize:0})
    const [state,setState] = useState({
        SearchTerm : "",
        SortBy : "rating",
        Tags:[],
        Categories:[],
        Page: 1
      });
    useEffect(() => {
         dispatch(fetchGames(state)).then(res => setGames(res)).catch(err => console.log(err))
    }, [state])
    const listedGames = games.results.map((game) =>
      <GameItem key={game.id} game={game}/>
    );
    const gameDisplay = listedGames.length !== 0 ? listedGames : <p>No Games Found</p>
    const onSearch = (SearchTerm) => {
        setState({...state,SearchTerm,Page:1})
    }
    const onSort = (SortBy) => {
        setState({...state,SortBy})
    }
    const onTagSort = (Tags) => {
        setState({...state,Tags,Page:1})
    }
    const onCategorySort = (Categories) => {
        setState({...state,Categories,Page:1})
    }
    const onPaginate = (Page) => {
        setState({...state,Page})
      }
    return (
        <div id="games-main-container" className="d-flex flex-column w-100 justify-content-center" >
            <GamesSortingBar onSearch={onSearch} onCategorySort={onCategorySort} onTagSort={onTagSort} onSort={onSort} tags={props.tags} categories={props.categories}/>
            <div id="game-grid">{gameDisplay}</div>
            <Pagination current={state.Page} pageSize={games.pageSize} pageCount={games.pageCount} onPaginate={onPaginate} />
        </div>
    );
}
export default Games;