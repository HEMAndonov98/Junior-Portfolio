import React from 'react'
import { Boxes } from './ui/background-boxes'
import MagicButton from './ui/magic-button'
import { FaLocationArrow } from 'react-icons/fa'
import { socialMedia } from '@/data'

const Footer = () => {
    return (
        <footer className='w-full mt-10 lg:mt-20 relative' id='contact'>
            <div className='w-full absolute left-0 -top-10 min-h-96 overflow-hidden opacity-25'>
                <Boxes />
            </div>

            <div className=' py-10 flex flex-col items-center'>
                <h1 className='heading lg:max-w-[45vw]'>Are you ready to start <span className='text-purple font-bold'>working</span> together?
                </h1>
                <p className='text-white-200 md:mt-10 my-5 text-center'>Reach out to me today and let&apos;s discuss how I can help your team achieve new hights
                </p>
                <a href="mailto:hristo.andonov98@gmail.com">
                    <MagicButton
                        title="Let's get in touch"
                        icon={<FaLocationArrow />}
                        position='right'
                    />
                </a>
            </div>

            <div className='md:mt-16 flex flex-col md:flex-row justify-between items-center'>
                <p className='text-white-200 text-sm font-light md:text-base md:font-normal '>Copyright © 2025 Hristo
                </p>

                <div className='flex my-2 items-center md:gap-3 gap-6'>
                    {socialMedia.map((profile) => (
                        <div key={profile.id}
                            className='w-10 h-10 cursor-pointer flex justify-center items-center
                        backdrop-filter backdrop-blur-lg saturate-180 bg-opacity-75 bg-black-200 rounded-lg border border-black-300'>
                            <a href={profile.link}>
                                <img src={profile.img} alt={profile.id.toString()} width={20} height={20} />
                            </a>
                        </div>
                    ))}
                </div>
            </div>
        </footer >
    )
}

export default Footer