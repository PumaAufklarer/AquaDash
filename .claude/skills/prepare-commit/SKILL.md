---
name: prepare-commit
description: Use when writing a Conventional Commit message for the HybridArms project
---

# Prepare Commit

## Overview
Helps the user write a Conventional Commit message following the HybridArms project format.

## Steps

1. **Ask for the commit type:**
   - feat (new feature)
   - fix (bug fix)
   - docs (documentation)
   - style (code style/formatting)
   - refactor (refactoring)
   - test (testing)
   - chore (build/tools)

2. **Ask for the scope** (optional, one of: gameplay, ui, ci, assets, docs)

3. **Ask for the issue number** (e.g., 123)

4. **Ask for a short description** (imperative, present tense)

5. **Generate the commit message** in this exact format:
   ```
   <type>(<scope>): <description> (#<issue-id>)
   ```

   Example: `feat(gameplay): add double jump (#42)`

   If the scope is omitted, omit the parentheses.

6. **Remind the user to run** `git config core.hooksPath .githooks` if they haven't already
