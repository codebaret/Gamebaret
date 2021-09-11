import GamesFilterElement from "./GamesFilterElement";
import './GamesFilter.scss';

function GamesFilter(props) {
    const content = props.gamefilters.map((gamefilter) =>
        <GamesFilterElement key={gamefilter.id} onclick={gamefilter.onclick} content={gamefilter.content} />
  );
    return (
      <div className="d-flex flex-column game-filters">
        {content}
      </div>
    );
}
export default GamesFilter;