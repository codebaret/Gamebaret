import PaginationElement from "./PaginationElement";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faChevronLeft,faChevronRight,faAngleDoubleLeft,faAngleDoubleRight } from '@fortawesome/free-solid-svg-icons'
import './Pagination.scss';
function Pagination(props) {
    const current = props.current;
    const pageCount = props.pageCount;
    const getPagination = (to,display=to) =>{
        return <PaginationElement to={to} display={display} current={current}
                 totalPages={pageCount} onPaginate={props.onPaginate} />;
    }
    let first = getPagination(1,<FontAwesomeIcon icon={faAngleDoubleLeft} />)
    let left = getPagination(current-3,<FontAwesomeIcon icon={faChevronLeft} />)
    let leftLeftElement = current===pageCount ? getPagination(current-2) : "";
    let leftElement = getPagination(current-1)
    let currentElement = getPagination(current)
    let rightElement = getPagination(current+1)
    let rightRightElement = current===1 ? getPagination(current+2) : "";
    let right = getPagination(current+3,<FontAwesomeIcon icon={faChevronRight} />)
    let last = getPagination(pageCount,<FontAwesomeIcon icon={faAngleDoubleRight} />)
    return(
        <div id="pagination-container" className="d-flex">
            {first}
            {left}
            {leftLeftElement}
            {leftElement}
            {currentElement}
            {rightElement}
            {rightRightElement}
            {right}
            {last}
        </div>
    )
}

export default Pagination;
