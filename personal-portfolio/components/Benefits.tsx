import React from 'react'
import { InfiniteMovingCards } from './ui/infinite-moving-cards'
import { testimonials } from '@/data'

const Benefits = () => {
    return (
        <div className='py-20'>
            <h1 className='heading mb-10'>
                What makes me a great fit for {' '}
                <span className='text-purple'>
                    your team
                </span>
            </h1>
            <div className='flex flex-col items-center justify-center'>
                <InfiniteMovingCards
                    items={testimonials}
                    direction='right'
                    speed='slow' />
            </div>
        </div>
    )
}

export default Benefits