import React, { useState } from 'react'
import './Auth.scss'
import { useDispatch } from 'react-redux'
import { login } from '../state/action-creator/index'
import AuthModal from './AuthModal'
import Register from './Register'

const Login = ({ history,setModal }) => {
    const dispatch = useDispatch()

    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')

    const onRegister = (e) => {
        setModal(<AuthModal close={()=>setModal("")} content={<Register setModal={setModal} />} />);
        
    }

    const submitForm = (e) => {
        e.preventDefault()

        dispatch(login({ username, password }, history))
        .then(r =>setModal("") )

    }

    return (
        <div id='auth-form-section'>
            <h6>Login</h6>
            <form onSubmit={submitForm}>
                <div id="inputs" className="d-flex">
                    <div className='input-field'>
                        <input
                            onChange={e => setUsername(e.target.value)}
                            value={username}
                            required='required'
                            type='text'
                            placeholder='Username' />
                    </div>

                    <div className='input-field'>
                        <input
                            onChange={e => setPassword(e.target.value)}
                            value={password}
                            required='required'
                            type='password'
                            placeholder='Password' />
                    </div>

                </div>
                
                <button>Login</button>
            </form>

            <p className="m-0">Don't have an account? <button id="auth-redirect" onClick={onRegister}>Register</button></p>
        </div>
    );
}

export default Login