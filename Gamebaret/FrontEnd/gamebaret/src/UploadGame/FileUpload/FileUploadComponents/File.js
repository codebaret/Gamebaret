import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons'

export default props => {
  return (
  <div className='fadein d-flex'>
    <p className="m-0 px-2">{props.file}</p>
    <div 
      onClick={() => props.removeFile()} 
      className='delete'
    >
      <FontAwesomeIcon icon={faTrashAlt} />
    </div>
    
  </div>
)
}