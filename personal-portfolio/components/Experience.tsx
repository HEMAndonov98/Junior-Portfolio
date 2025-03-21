import { workExperience } from '@/data'
import React from 'react'
import { Button } from './ui/moving-border'
import { IconSquare, IconSquareFilled } from '@tabler/icons-react'

const Experience = () => {
    return (
        <div className='py-15' id='experience'>
            <h1 className='heading mb-10'>
                My{' '}
                <span className='text-purple'>
                    skills
                </span>
            </h1>
            <div className='w-full my-10 grid lg:grid-cols-4 grid-cols-1 gap-10'>
                {workExperience.map((data) => (
                    <Button
                        key={data.id}
                        duration={Math.floor(Math.random() * 10000) + 10000}
                        className='flex-1 text-white border-neutral-200 dark:border-slate-800 w-full cursor-default'>
                        <div className='my-5'>
                            <h1 className='text-3xl font-bold mb-5'>
                                {data.title}
                            </h1>
                            <ul>
                                {data.technology.map((skill) => (
                                    <li key={skill.name} className='sm:ms-5 my-2 flex flex-col sm:flex-row lg:gap-5 sm:justify-between'> <span className='font-semibold text-sm sm:text-lg'>{skill.name}</span> {progress(skill.level)}</li>
                                ))}
                            </ul>
                        </div>
                    </Button>
                ))}
            </div>
        </div>
    )
}

const progress = (level: number) => {
    return (
        <div className='flex gap-2 w-fill justify-center items-center scale-75 sm:scale-50'>
            {Array.from({ length: 10 }).map((_, index) => (
                index < level ? (
                    <IconSquareFilled
                        className='text-purple'
                        key={index}
                    />
                ) : (
                    <IconSquare
                        key={index}
                    />
                )
            ))}
        </div>
    )
}

export default Experience