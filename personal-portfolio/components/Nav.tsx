import React from 'react'
import { IconBooks, IconHome, IconMoodLookUp, IconUser } from "@tabler/icons-react";
import { GoProjectRoadmap } from "react-icons/go"
import { FloatingNav } from './ui/floating-navbar';
// TODO Add Education section link

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
    name: "Benefits",
    link: "#benefits",
    icon: (
      <IconMoodLookUp className="h-4 w-4 text-neutral-500 dark:text-white" />
    ),
  },
  {
    name: "Experience",
    link: "#experience",
    icon: (
      <IconMoodLookUp className="h-4 w-4 text-neutral-500 dark:text-white" />
    ),
  },
  {
    name: "Education",
    link: "#education",
    icon: (
      <IconBooks className="h-4 w-4 text-neutral-500 dark:text-white" />
    ),
  },
];

const Nav = () => {
  return (
    <nav>
      <FloatingNav navItems={navItems} />
    </nav>
  )
}

export default Nav