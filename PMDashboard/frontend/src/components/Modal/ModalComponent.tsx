import Modal from '@mui/material/Modal';
import { useEffect, useState } from 'react';
import { createPortal } from 'react-dom';

export default function ModalComponent({open, onClose, children}: {open: boolean, onClose: () => void, children: React.ReactNode}) {
    const [domReady, setDomReady] = useState(false)
    useEffect(() => {
        setDomReady(true)
    }, [])
    return domReady ? createPortal(
        <Modal
            open={open}
            onClose={() => onClose()}
            disablePortal={true}
            >
            <div style={{
                position: 'absolute',
                top: '50%',
                left: '50%',
                transform: 'translate(-50%, -50%)',
                backgroundColor: 'white',
                color: 'black',
                padding: '20px',
                borderRadius: '10px'
            }}>
                {children}
            </div>
        </Modal>,
        document.getElementById('modal-root')!) : null
}