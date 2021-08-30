import './GamesSortingBar.scss';
import { GameSearch } from './GameSearch';
import {GameSort} from './GameSort';

function GamesSortingBar(props) {
    const onSearch = (searchTerm) => {
        console.log(searchTerm);
    }
    const onSort = (sortBy) => {
        console.log(sortBy);
    }
    return (
      <div className="d-flex justify-content-between align-items-center w-100">
        <GameSearch onSearch={onSearch} />
        <GameSort onSort={onSort} />
      </div>
    );
}
export default GamesSortingBar;