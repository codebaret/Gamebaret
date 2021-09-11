import React, { useState } from 'react'
import { useDispatch,useSelector } from 'react-redux'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCloudUploadAlt } from '@fortawesome/free-solid-svg-icons'

const OperationsSection = ({ }) => {
    const dispatch = useDispatch()
    const isLoggedIn = useSelector(state => state.authReducer.isLoggedIn);
    let upload = isLoggedIn ? <Link className="h-100 d-flex align-items-center" to="/uploadgame"><FontAwesomeIcon className="c-pointer" icon={faCloudUploadAlt} /></Link> : "";
    return (
        <div id="auth-logos" className="d-flex">
            {upload}
            
        </div>
    );
}

export default OperationsSection