import React from 'react';
import { ITask } from '../types/task'
import { FaTimes } from 'react-icons/fa'

interface TaskProps {
    task: ITask
    , onDelete: any
    , onToggle: any
}

const iconStyle = {
    color: 'red'
    , cursor: 'pointer'
}

const Task = ( {task, onDelete, onToggle} : TaskProps) => {
    return (
        <div 
            className={`task ${task.reminder ? 'reminder': ''}`}
            onDoubleClick={() => onToggle(task.id)}>
            
            <h3>{task.text} 
                <FaTimes 
                    style= {iconStyle} 
                    onClick={() => onDelete(task.id)}/>
            </h3>
            
            <p>{task.day}</p>
        </div>
    )
}

export default Task;