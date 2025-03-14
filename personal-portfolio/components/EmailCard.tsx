'use client';

import React from 'react';
import MagickButton from './ui/magickButton';
import { IoCopyOutline } from 'react-icons/io5';
import { useState } from 'react';
import animationData from '@/data/confetti.json';
import dynamic from 'next/dynamic';


const Lottie = dynamic(() => import('lottie-react'), { ssr: false });


export const EmailCard = () => {
        const [coppied, setCopied] = useState(false);
        const handleCopy = () => {
           if (typeof navigator !== 'undefined' && navigator?.clipboard) {
                navigator.clipboard.writeText('hristo.andonov98@gmail.com');
                setCopied(true);
            }
        }

        const defaultRendererSettings = {
            preserveAspectRatio: 'xMidYMid slice'
            }
  return (
    
    <div className="mt-2 relative">
                <div className={'absolute -bottom-5 right-0'}>
                  <Lottie 
                    loop={coppied}
                    autoplay={coppied}
                    animationData={animationData}
                    rendererSettings={defaultRendererSettings}                    
                    />
                </div>
                <MagickButton
                title={ coppied ? 'Email copied' : 'Copy my email'}
                icon={<IoCopyOutline />}
                position='left'
                other='bg-[#161a31]'
                handleClick={handleCopy}
                 />
              </div>
  )
}

export default EmailCard