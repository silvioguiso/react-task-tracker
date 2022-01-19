import React from "react";
import { useLocation } from "react-router-dom";
import Button from './Button'

interface HeaderProps {
    title:string,
    onAdd: any,
    showAddTask: boolean
}

const Header = ( { title, onAdd, showAddTask }: HeaderProps) => {
    const location = useLocation();

    return(
        <header className='header'>
            <h1>{ title }</h1>
            { location.pathname === '/' && <Button 
                text={showAddTask ? 'Close' : 'Add'} 
                color={showAddTask ? 'red' : 'green'}  
                onClick={onAdd} /> }
        </header>
    )
}

Header.defaultProps = {
    title: 'Task Tracker'
}

export default Header;