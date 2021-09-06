import './Games.scss';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faStar } from '@fortawesome/free-solid-svg-icons'
import {Link} from 'react-router-dom'

function GameItem(props) {
    let game = props.game;
    let imgUrl = `data:image/jpeg;charset=utf-8;base64,${game.image}`;
    var backgroundImage = {
        backgroundImage: `url(${imgUrl})`
      };
    let gameLink = `/game/${game.id}`
    const listedTags = game.tags.map((tag,index) =>
      <div className="game-info-list-element light" key={index} >{tag}</div>
    );
    const listedCategories = game.categories.map((category,index) =>
      <div className="game-info-list-element yellow" key={index} >{category}</div>
    );
    const creator = <span className="yellow-text"> {game.userName}</span>;
    const createdDate = <span className="yellow-text"> {new Date(game.date).toLocaleDateString()}</span>;
    console.log(game);
    return (
      <Link to={gameLink} id="game-list-item">
        
        <div id="game-list-image" style={backgroundImage}>
            <div id="game-info">
              <div id="game-header" className="d-flex justify-content-between w-100">
                <p>{game.name}</p>
                <div className="d-flex align-items-center">
                    <p>{game.rating}</p>
                    <FontAwesomeIcon icon={faStar} />
                </div>
              </div>
              <div className="d-flex flex-wrap">
                {listedTags}
              </div>
              <div className="d-flex flex-wrap">
                {listedCategories}
              </div>
              <div id="additional-game-info">
                <p>{game.description}</p>
                <p>{"Created by "}{creator}{" on "}{createdDate}</p>
              </div>
            </div>
        </div>
      </Link>
    );
}
export default GameItem;  