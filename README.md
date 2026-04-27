![CO-1](https://github.com/user-attachments/assets/7b600675-587d-4e1a-9786-2ea50e35d8a7)

## 🥁 CarnaCode 2026 - Challenge 13 - Chain of Responsibility

Hi, I am Felipe Parizzi Galli, and this is the space where I share my learning journey during the **CarnaCode 2026** challenge, hosted by [balta.io](https://balta.io). 👻

Here you will find projects, exercises, and code I am building throughout the challenge. The goal is to get hands-on, test ideas, and track my growth in the tech world.

### About this challenge
In the **Chain of Responsibility** challenge, I had to solve a real-world problem by implementing this **Design Pattern**.
In this process, I learned:
* ✅ Software Best Practices
* ✅ Clean Code
* ✅ SOLID
* ✅ Design Patterns

## Problem
A company needs to process reimbursement requests with different approval levels based on amount.
The current code uses large conditional blocks and is hard to maintain when new approval levels are added.

## About CarnaCode 2026
The **CarnaCode 2026** challenge consists of implementing all 23 design patterns in real-world scenarios. Across the 23 challenges in this journey, participants practice identifying non-scalable code and solving problems with industry-standard patterns.

### eBook - Design Pattern Fundamentals
My main learning source during this challenge was the free eBook [Fundamentos dos Design Patterns](https://lp.balta.io/ebook-fundamentos-design-patterns).

## What was implemented in code (Chain of Responsibility)
- The monolithic approval flow was replaced with a chain-based flow in `DesignPatternChallenge/src/Services/ExpenseApprovalSystem.cs`.
- The base handler `Approver` was created in `DesignPatternChallenge/src/Services/Approvers/Approver.cs`, including shared validation methods and next-handler linking.
- Four concrete handlers were added:
  - `SupervisorApprover` (`DesignPatternChallenge/src/Services/Approvers/SupervisorApprover.cs`)
  - `ManagerApprover` (`DesignPatternChallenge/src/Services/Approvers/ManagerApprover.cs`)
  - `DirectorApprover` (`DesignPatternChallenge/src/Services/Approvers/DirectorApprover.cs`)
  - `CEOApprover` (`DesignPatternChallenge/src/Services/Approvers/CEOApprover.cs`)
- `ExpenseApprovalSystem` now builds and executes the chain with `SetNext(...)` and starts processing from the first handler.
- The previous switch-based alternative implementation (`ExpenseApprovalSystemV2`) was removed because the handler chain now covers the approval flow.
