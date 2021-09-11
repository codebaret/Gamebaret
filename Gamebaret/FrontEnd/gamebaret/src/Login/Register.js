import React, { useState } from 'react'
import { useDispatch } from 'react-redux'
import { register } from '../state/action-creator/index'
import './Auth.scss'
import AuthModal from './AuthModal'
import Login from './Login'

const Register = ({ history,setModal }) => {

    const dispatch = useDispatch()

    const [username, setUsername] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    const onLogin = (e) => {
        setModal(<AuthModal close={()=>setModal("")} content={<Login setModal={setModal} />} />);   
    }

    const submitForm = (e) => {
        e.preventDefault()

        dispatch(register({ username, email, password }, history))
        .then(r =>setModal( <AuthModal close={()=>setModal("")} content={<Login setModal={setModal} />} />) )
    }

    return (
        <div id='auth-form-section'>
            <h6>Register</h6>
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
                        onChange={e => setEmail(e.target.value)}
                        value={email}
                        required='required'
                        type='text'
                        placeholder='Email' />
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
                
                <button>Register</button>
            </form>

            <p>Already have an account? <button id="auth-redirect" onClick={onLogin}>Login</button></p>
        </div>
    );
}

export default Register