import React from 'react'
import { ITask } from '../types/task'
import Task from './Task'

interface TasksProps {
    tasks: ITask[]
    , onDelete: any
    , onToggle: any
}

const Tasks = ( {tasks, onDelete, onToggle}: TasksProps) => {

    return (
        <>
        {tasks.map((x) => (
            <Task 
                key={x.id.toString()} 
                task={x} 
                onDelete={onDelete}
                onToggle={onToggle} />
        ))}
        </>
    )
}

export default Tasks;