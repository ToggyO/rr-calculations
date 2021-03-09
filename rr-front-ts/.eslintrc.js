module.exports = {
  parser: '@typescript-eslint/parser',
  parserOptions: {
    project: ['./tsconfig.json'],
  },
  plugins: [
    '@typescript-eslint/eslint-plugin',
    // 'prettier'
    // 'import'
  ],
  extends: [
    'airbnb-typescript',
    'airbnb/hooks',
    'plugin:@typescript-eslint/recommended',
    'plugin:@typescript-eslint/recommended-requiring-type-checking',
    // 'prettier/@typescript-eslint',
    // 'plugin:prettier/recommended',
  ],
  root: true,
  env: {
    node: true,
  },
  ignorePatterns: ['.eslintrc.js'],
  // settings: {
  //   'import/parsers': {
  //     '@typescript-eslint/parser': ['.ts','.tsx']
  //   },
  //   'import/resolver': {
  //     typescript: {
  //       alwaysTryTypes: true,
  //       project: ['./tsconfig.json'],
  //     }
  //   }
  // },
  rules: {
    // 'prettier/prettier': ['error'],
    '@typescript-eslint/interface-name-prefix': 'off',
    '@typescript-eslint/explicit-function-return-type': 'off',
    '@typescript-eslint/explicit-module-boundary-types': 'off',
    '@typescript-eslint/no-explicit-any': 'off',
    '@typescript-eslint/no-empty-function': ['error', { 'allow': ['methods','constructors'] }],
    '@typescript-eslint/consistent-type-imports': ['warn', { 'prefer': 'type-imports' }],
    '@typescript-eslint/no-inferrable-types': 'warn',
    '@typescript-eslint/no-unsafe-member-access': 'off',
    '@typescript-eslint/no-unsafe-assignment': 'off',
    '@typescript-eslint/no-unsafe-return': 'off',
    '@typescript-eslint/no-unsafe-call': 'off',
    'no-console': 'warn', // Remember, this means error!
    // 'import/no-unresolved': 'error',
    'import/extensions': 'off',
    'no-debugger': 'warn',
    'arrow-body-style': ['error', 'as-needed'],
    'arrow-parens': 'error',
    'curly': ['warn', 'all'],
    'func-names': 'off',
    'import/prefer-default-export': 'off',
    'max-len': ['error', { 'code': 120 }],
    'no-param-reassign': 'off',
    'no-plusplus': 'off',
    'no-tabs': 'off',
    'no-underscore-dangle': 'error',
    'jsx-a11y/mouse-events-have-key-events': 'error',
    'react/jsx-filename-extension': [2, { 'extensions': ['.js', '.jsx', '.ts', '.tsx'] }],
    'react/jsx-props-no-spreading': 'off',
    'react/state-in-constructor': 'error',
    'react/destructuring-assignment': ['error', 'always'],
    'react/prop-types': 'off',
    'react/forbid-prop-types': 'off',
    'react-hooks/rules-of-hooks': 'error',
    'react-hooks/exhaustive-deps': 'error',
    'valid-jsdoc': 'warn'
  },
};