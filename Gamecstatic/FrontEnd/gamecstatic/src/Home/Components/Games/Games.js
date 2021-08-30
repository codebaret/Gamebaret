import GamesFilter from "./GamesFilter/GamesFilter";
import GamesSortingBar from "./GamesSortingBar/GamesSortingBar";

function Games() {
    const gamefilters = [{id:1,content:"content",onclick:null},{id:2,content:"content2",onclick:null}]
    return (
      <div className="d-flex p-5">
        <GamesFilter gamefilters={gamefilters}/>
        <div className="d-flex flex-column w-100">
            <GamesSortingBar/>
        </div>
      </div>
    );
}
export default Games;