import './GamesSortingBar.scss';
import { GameSearch } from './GameSearch';
import {GameSort} from './GameSort';
import GameMultiSelect from './GameMultiSelect';
import Accordion from 'react-bootstrap/Accordion'
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faFilter } from '@fortawesome/free-solid-svg-icons'

function GamesSortingBar(props) {
    return (
      <div id="games-sorting-main-container">
        <Accordion>
          <Card>
            <Card.Header>
              <Accordion.Toggle as={Button} 
                variant="link" eventKey="0">
               <FontAwesomeIcon icon={faFilter} />
              </Accordion.Toggle>
            </Card.Header>
            <Accordion.Collapse eventKey="0">
              <Card.Body>
              <div id="games-sorting-bar" className="d-flex justify-content-between align-items-center w-100">
                <GameSearch onSearch={props.onSearch} />
                <GameMultiSelect onChange={props.onTagSort} placeholder="Sort by Tags" values={props.tags}/>
                <GameMultiSelect onChange={props.onCategorySort} placeholder="Sort by Categories" values={props.categories}/>
                <GameSort onSort={props.onSort} />
              </div>
              </Card.Body>
            </Accordion.Collapse>
          </Card>
        </Accordion>
      </div>
      
      
    );
}
export default GamesSortingBar;