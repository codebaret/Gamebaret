import './Navigation.scss';
import Login from '../../Login/Login';
import Register from '../../Login/Register';
import { useState } from 'react'
import { useSelector } from 'react-redux'
import Logout from '../../Login/Logout';
import { Link } from 'react-router-dom'
import AuthModal from '../../Login/AuthModal';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faKey,faPlus } from '@fortawesome/free-solid-svg-icons'

function AuthSection() {
     const isLoggedIn = useSelector(state => state.authReducer.isLoggedIn);
     const [modal, setModal] = useState("");
     let registerModal = <AuthModal close={()=>setModal("")} content={<Register setModal={setModal} />} />;
     let loginModal = <AuthModal close={()=>setModal("")} content={<Login setModal={setModal} />} />;
     let content = <div id="auth-logos" className="d-flex align-items-center">
       <FontAwesomeIcon onClick={()=>setModal(loginModal)} icon={faKey} />
       <FontAwesomeIcon onClick={()=>setModal(registerModal)} icon={faPlus} />
     </div>
     content = isLoggedIn ? <Logout/> : content;
    return (
        <div className="d-flex align-items-center">
            {content}
            {modal}
        </div>
    );
}
export default AuthSection;