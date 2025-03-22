import { projects } from '@/data';
import React from 'react';
import { PinContainer } from './ui/3d-pin';
import { FaLocationArrow } from "react-icons/fa";

const RecentProjects = () => {
    return (
        <section id='projects'>
            <div className='py-20'>
                <h1 className='heading'>
                    A small selection of {' '}
                    <span className='text-purple'>
                        recent projects
                    </span>
                </h1>
                <div className='flex flex-wrap items-center justify-center p-4 gap-14  mt-10'>
                    {projects.map(({ id,
                        title,
                        des,
                        img,
                        iconLists,
                        link
                    }) => (
                        <div key={id} className='lg:min-h-[32.5rem] h-[25rem] flex justify-center items-center sm:w-96 w-[80vw] lg:w-[35rem]'>
                            <PinContainer title={link} href={link}>
                                <div className='relative flex items-center justify-center sm:w-96 w-[80vw] lg:w-[35rem] overflow-hidden h-[20vh] lg:h-[30vh] mb-10'>
                                    <div className='relative w-full h-ful object-cover overflow-hidden lg:rounded-3xl bg-[#13162d]'>
                                        <img src='/bg.png' alt='/bg.png' />
                                    </div>
                                    <img
                                        src={img}
                                        alt={title}
                                        className='z-10 absolute px-2'
                                    />
                                </div>
                                <h1 className='font-bold lg:text-2xl md:text-xl text-base line-clamp-1'>
                                    {title}
                                </h1>

                                <p className='lg:text-xl lg:font-normal font-light text-sm line-clamp-2'>
                                    {des}
                                </p>

                                <div className='flex justify-between items-center mt-7 mb-3'>
                                    <div className='flex items-center'>
                                        {iconLists.map((icon, index) => (
                                            <div key={icon} className='border border-white/[0.2] rounded-full bg-black lg:w-10 lg:h-10 w-9 h-9 flex justify-center items-center hover:w-14 hover:h-14 hover:z-10'
                                                style={{ transform: `translateX(-${5 * index * 2}px)` }}>
                                                <img src={icon} alt={icon} className='p-2' />
                                            </div>
                                        ))}
                                    </div>

                                    <div className='flex items-center justify-cente border border-white/[0.2] bg-black rounded-lg p-2'>
                                        <p className='flex lg:text-xl md:text-xs text-sm text-purple hover:opacity-65'>Check Repo</p>
                                        <FaLocationArrow className='ms-3' color='#CBACF9' />
                                    </div>
                                </div>
                            </PinContainer>
                        </div>
                    ))}
                </div>
            </div>
        </section>
    )
}

export default RecentProjects