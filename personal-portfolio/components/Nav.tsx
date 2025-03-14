import React from 'react'
import { IconHome, IconMessage, IconUser } from "@tabler/icons-react";
import { GoProjectRoadmap } from "react-icons/go"
import { FloatingNav } from './ui/floating-navbar';


const navItems = [
    {
      name: "Home",
      link: "/",
      icon: <IconHome className="h-4 w-4 text-neutral-500 dark:text-white" />,
    },
    {
      name: "About",
      link: "#about",
      icon: <IconUser className="h-4 w-4 text-neutral-500 dark:text-white" />,
    },
    {
      name: "Projects",
      link: "#projects",
      icon: <GoProjectRoadmap className="h-4 w-4 text-neutral-500 dark:text-white" />,
    },
    {
      name: "Contact",
      link: "/contact",
      icon: (
        <IconMessage className="h-4 w-4 text-neutral-500 dark:text-white" />
      ),
    },
  ];

const Nav = () => {
  return (
    <nav>
        <FloatingNav navItems={navItems}/>
    </nav>
  )
}

export default Nav