"use client";
import React from "react";

import { AnimatePresence, motion } from "motion/react";
import { CanvasRevealEffect } from "@/components/ui/canvas-reveal-effect";

const Education = () => {
    return (
        <>
            <section id="education" className="w-full pb-20">
                <h1 className="heading">Education & <span className="text-purple">Certification</span></h1>
                <div className="my-20 flex flex-col lg:flex-row items-center justify-center gap-4">
                    <Card
                        title="SoftUni"
                        icon={<AceternityIcon iconTitle='Education' />}
                        description="Pursuing the C# Web Developer Path at SoftUni Bulgaria, complemented by courses in data structures and algorithms. Continuously honing problem-solving skills through LeetCode and personal projects, applying knowledge to real-world development challenges.">
                        <CanvasRevealEffect
                            animationSpeed={3}
                            containerClassName="bg-emerald-900"
                        />
                    </Card>
                    <Card title="Nisha is Munni"
                        icon={<AceternityIcon iconTitle='Certification' />}
                        description={`
                                C# Advanced - May 2022 \nC# OOP - June 2022 \nDSA Fundamentals - November 2022 \nMS SQL - January 2023 \nEF Core - January 2023 \nHTML & CSS - May 2024
                        `}>
                        <CanvasRevealEffect
                            animationSpeed={3}
                            containerClassName="bg-black"
                            colors={[
                                [236, 72, 153],
                                [232, 121, 249],
                            ]}
                            dotSize={2}
                        />
                        {/* Radial gradient for the cute fade */}
                        <div className="absolute inset-0 [mask-image:radial-gradient(400px_at_center,white,transparent)] bg-black/50 dark:bg-black/90" />
                    </Card>
                    <Card title="Future Aspirations"
                        icon={<AceternityIcon iconTitle='Future' />}
                        description="In the future, I aim to pursue a professional degree in Computer Science and Engineering. My goal is to deepen my understanding of technology and apply my skills to create impactful solutions that benefit society.">
                        <CanvasRevealEffect
                            animationSpeed={3}
                            containerClassName="bg-sky-600"
                            colors={[[125, 211, 252]]}
                        />
                        {/* Radial gradient for the cute fade */}
                        <div className="absolute inset-0 [mask-image:radial-gradient(400px_at_center,white,transparent)] bg-black/50 dark:bg-black/90" />
                    </Card>
                </div>
            </section>
        </>
    );
}

const Card = ({
    title,
    icon,
    children,
    description,
}: {
    title: string;
    icon: React.ReactNode;
    children?: React.ReactNode;
    description: string;
}) => {
    const [hovered, setHovered] = React.useState(false);
    return (
        <div
            onMouseEnter={() => setHovered(true)}
            onMouseLeave={() => setHovered(false)}
            className="border border-black/[0.2] group/canvas-card flex items-center justify-center dark:border-white/[0.2]  max-w-sm w-full mx-auto p-4 lg:h-[35rem] h-[60vh] relative"
        >
            <Icon className="absolute h-6 w-6 -top-3 -left-3 dark:text-white text-black" />
            <Icon className="absolute h-6 w-6 -bottom-3 -left-3 dark:text-white text-black" />
            <Icon className="absolute h-6 w-6 -top-3 -right-3 dark:text-white text-black" />
            <Icon className="absolute h-6 w-6 -bottom-3 -right-3 dark:text-white text-black" />

            <AnimatePresence>
                {hovered && (
                    <motion.div
                        initial={{ opacity: 0 }}
                        animate={{ opacity: 1 }}
                        className="h-full w-full absolute inset-0"
                    >
                        {children}
                    </motion.div>
                )}
            </AnimatePresence>

            <div className="relative z-20">
                <div className="text-center group-hover/canvas-card:-translate-y-4 absolute top-[50%] left-[50%] translate-x-[-50%] translate-y-[-50%] group-hover/canvas-card:opacity-0 transition duration-200 w-full  mx-auto flex items-center justify-center">
                    {icon}
                </div>
                <h2 className="dark:text-white text-3xl text-center opacity-0 group-hover/canvas-card:opacity-100 relative z-10 text-black mt-4  font-bold group-hover/canvas-card:text-white group-hover/canvas-card:-translate-y-2 transition duration-200">
                    {title}
                </h2>
                <p style={{ whiteSpace: "pre-line" }} className="dark:text-white text-xl text-center opacity-0 group-hover/canvas-card:opacity-100 relative z-10 text-black mt-4  font-bold group-hover/canvas-card:text-white group-hover/canvas-card:-translate-y-2 transition duration-200">
                    {description}
                </p>
            </div>
        </div>
    );
};

const AceternityIcon = ({ iconTitle }: { iconTitle: string }) => {
    return (
        <button className="relative inline-flex h-12 overflow-hidden rounded-full p-[1px] focus:outline-none focus:ring-2 focus:ring-slate-400 focus:ring-offset-2 focus:ring-offset-slate-50">
            <span className="absolute inset-[-1000%] animate-[spin_2s_linear_infinite] bg-[conic-gradient(from_90deg_at_50%_50%,#E2CBFF_0%,#393BB2_50%,#E2CBFF_100%)]" />
            <span className="inline-flex h-full w-full cursor-pointer items-center justify-center rounded-full bg-slate-950 px-5 py-2 text-2xl font-bold text-white backdrop-blur-3xl">
                {iconTitle}
            </span>
        </button>
    );
};

export default Education;

export const Icon = ({ className, ...rest }: any) => {
    return (
        <svg
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            strokeWidth="1.5"
            stroke="currentColor"
            className={className}
            {...rest}
        >
            <path strokeLinecap="round" strokeLinejoin="round" d="M12 6v12m6-6H6" />
        </svg>
    );
};
