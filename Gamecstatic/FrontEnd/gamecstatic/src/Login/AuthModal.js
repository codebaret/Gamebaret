import { Modal } from "react-bootstrap"
import { Button } from "react-bootstrap";
import { useState,useEffect } from "react";

function AuthModal(props) {
    const [show, setShow] = useState(true);
    const handleClose = () => {
        setShow(false);
        props.close();
    }
    return(
        <Modal id="modal" show={show} onHide={handleClose}>
            <Modal.Body>{props.content}</Modal.Body>
            <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
                Close
            </Button>
            </Modal.Footer>
        </Modal>
    )
}

export default AuthModal;