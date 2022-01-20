import React from 'react'

interface ButtonProps {
    text: string,
    color: string,
    onClick: any
}

const Button = ( {text, color,onClick}: ButtonProps) => {
    
    return(
        <button
            onClick={onClick}
            style={{backgroundColor: color}} 
            className='btn'>
            {text}
        </button>
    )
}

Button.defaultProps = {
    color: 'steelblue'
}

export default Button;