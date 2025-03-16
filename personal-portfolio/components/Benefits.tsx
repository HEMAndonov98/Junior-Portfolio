import React from 'react'
import { InfiniteMovingCards } from './ui/infinite-moving-cards'
import { testimonials } from '@/data'

const Benefits = () => {
    return (
        <div className='py-15' id='benefits'>
            <h1 className='heading mb-10'>
                What makes me a great fit for {' '}
                <span className='text-purple'>
                    your team
                </span>
            </h1>
            <div className='flex flex-col items-center justify-center mb-10'>
                <div className='h-[50vh] md:h-[30rem] rounded-md flex flex-col antialiased items-center relative overflow-hidden'>
                    <InfiniteMovingCards
                        items={testimonials}
                        direction='right'
                        speed='slow' />
                </div>
            </div>
        </div>
    )
}

export default Benefits