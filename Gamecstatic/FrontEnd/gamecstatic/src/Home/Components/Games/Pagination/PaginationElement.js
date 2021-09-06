

function PaginationElement(props) {
    let nonNumber = props.to !== props.display
    let outOfRange = (props.to < 1 || props.to > props.totalPages);
    if(!nonNumber && outOfRange) return '';
    let active = props.current === props.to && !nonNumber;
    let deactive = nonNumber && !active && (outOfRange || props.current === props.to);
    let classList = active ? "active" : "";
    classList = deactive ? "deactive" : classList;
    return(
        <div className={"pagination-element " + classList} onClick={()=> deactive ? "" : props.onPaginate(props.to)}>
            {props.display}
        </div>
    )
}

export default PaginationElement;